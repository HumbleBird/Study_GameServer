using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    //class Lock
    //{
    //    // bool <- 커널
    //    ManualResetEvent _available = new ManualResetEvent(true);
    //    //AutoResetEvent _available = new AutoResetEvent(true);

    //    public void Acquire()
    //    {
    //        // AutoResetEvent 에서는 자동으로 _available.Reset()해줌
    //        _available.WaitOne(); // 입장 시도

    //        // ManualResetEvent
    //        _available.Reset(); // 문 닫기

    //    }

    //    public void Release()
    //    {
    //        _available.Set(); // flag = true
    //    }
    //}

    class Program
    {
        static int _num = 0;


        // 몇 번 잠갔는지 카운트 함.
        // ThreadID를 가지고 있음
        // AutoReSetEvent보다 성능을 잡아 먹음. 갖고 있는 정보가 많으니. 
        static Mutex _lock = new Mutex();

        static void Thread_1()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _num++;
                _lock.ReleaseMutex();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _num--;
                _lock.ReleaseMutex();
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(_num);
        }
    }
}
