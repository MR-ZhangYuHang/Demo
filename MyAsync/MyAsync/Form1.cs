using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsync
{
    /// <summary>
    /// 1 进程、线程、同步、异步的概念
    /// 2 回顾委托，开始异步
    /// 3 异步多线程的三大特点
    /// 
    /// 进程：计算机概念  一个程序在运行时，占用的全部计算资源  整体称之为进程
    /// 线程：计算机概念  一个程序响应操作的最小单位，也有自己计算资源（任何操作都是需要线程来处理）
    /// Thread  是框架封装的类  用来描述线程
    /// 多线程：一个进程可以有多个线程同时工作
    /// 
    /// 1 异步的回调和状态参数
    /// 2 异步等待三种方式
    /// 3 获取异步的返回值
    /// </summary>
    public partial class frmAsync : Form
    {
        public frmAsync()
        {
            Console.WriteLine("欢迎来到.net高级班公开课之核心语法特训，今天是Eleven老师为大家带来的异步多线程");
            InitializeComponent();

        }

        #region 0301
        #region btnSync_Click
        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnSync_Click 同步方法 start {0}********************", Thread.CurrentThread.ManagedThreadId);
            int j = 0;
            int k = 1;
            int m = j + k;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("{0}_{1}", "btnSync_Click", i);
                this.DoSomethingLong(name);//同步方法：每次发起调用，必须等着调用结束，才进入下一行
            }

            Console.WriteLine("******************btnSync_Click 同步方法 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }
        #endregion

        #region btnAsync_Click
        /// <summary>
        /// 委托的异步调用   异步是基于委托
        /// 1 同步方法卡界面，主线程(UI线程)忙于计算；异步多线程方法不卡界面，主线程闲下来了，计算任务交给了子线程
        ///   耗时长的操作，可以异步完成，不卡界面；用户提交订单后需要发邮件，异步发邮件，直接返回用户
        /// 2 同步方法慢，只有一个线程干活；异步多线程方法快，多个线程同时计算
        ///   并不是线性提升，资源换时间， 资源有上限/线程调度也是有成本的；线程不是越多越好
        /// 3 异步多线程是无序：启动无序；结束无序；执行时间也不确定；
        ///   请不要用时间差来控制顺序
        ///   回调  阻塞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnAsync_Click 异步方法 start {0}********************", Thread.CurrentThread.ManagedThreadId);

            Action<string> act = new Action<string>(this.DoSomethingLong);

            //act.Invoke("btnAsync_Click_1");
            ////同步方法：每次发起调用，必须等着调用结束，才进入下一行
            ////请小罗吃饭，诚心诚意，我请你吃饭，就一定等着你忙完手头的事儿，然后一起去吃饭
            //act.BeginInvoke("btnAsync_Click_2", null, null);
            ////异步方法：每次发起调用，就立即进入下一行，不会等待，任务会启动一个新线程去执行
            ////请心如迷醉吃饭，客气一下，我说一声吃饭，然后就自己去吃饭了，你什么时候去吃饭，随便

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format("{0}_{1}", "btnAsync_Click", i);
                act.BeginInvoke(name, null, null);
            }

            Console.WriteLine("******************btnAsync_Click 异步方法 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }
        #endregion
        #endregion

        #region 0305
        /// <summary>
        /// 1 异步的回调和状态参数
        /// 2 异步等待三种方式
        /// 3 获取异步的返回值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnAsyncAdvanced_Click 异步方法进阶 start {0}********************", Thread.CurrentThread.ManagedThreadId);
            Action<string> action = new Action<string>(this.DoSomethingLong);
            //1 回调  

            //IAsyncResult asyncResult = null;
            //AsyncCallback asyncCallback = new AsyncCallback(
            //    r =>
            //Console.WriteLine("计算已经完成，记录一下日志 {0} {1}", Thread.CurrentThread.ManagedThreadId, r.AsyncState));

            //asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", asyncCallback, "心如迷醉");//异步调用
            ////委托发起异步调用产生一个临时结果(描述异步调用)，这个结果会作为参数，去调用回调的委托
            //Console.WriteLine(asyncResult.AsyncState);
            ////Console.WriteLine("计算已经完成，记录一下日志 {0}", Thread.CurrentThread.ManagedThreadId);

            ////2等待异步结果
            //IAsyncResult asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", null, null);

            ////int i = 0;
            ////while (!asyncResult.IsCompleted)
            ////{
            ////    //1 卡界面  因为主线程在等待 在忙碌  所以卡      可以做边上传边提示用户等待
            ////    //2 会有性能损失，可能最多多等待200ms
            ////    Thread.Sleep(200);
            ////    if (i < 10)
            ////        Console.WriteLine("文件上传完成{0}%", i++ * 10);
            ////    else
            ////        Console.WriteLine("文件上传完成99%");
            ////}
            ////Console.WriteLine("文件上传成功，您可以继续别的操作了");

            ////asyncResult.AsyncWaitHandle.WaitOne();//一直等着异步结束  不会有性能损失 
            ////asyncResult.AsyncWaitHandle.WaitOne(-1);//一直等着异步结束  不会有性能损失 
            ////asyncResult.AsyncWaitHandle.WaitOne(1000);//最多只等待1000ms  过时不候 超时就进入下一行(原线程任务还是继续)  
            ////超时控制    不会有性能损失   但是也不能做别的提示操作

            //action.EndInvoke(asyncResult);//也是等待

            Func<int> func = new Func<int>(
                () =>
                {
                    Thread.Sleep(2000);
                    return DateTime.Now.Year;
                }
                );

            int iResult = func.Invoke();

            IAsyncResult asyncResult = func.BeginInvoke(r =>
            {
                int iEndResultIn = func.EndInvoke(r);
                Console.WriteLine("计算已经完成，记录一下日志 {0} {1}", Thread.CurrentThread.ManagedThreadId, iEndResultIn);
            }, null);
            //int iEndResult = func.EndInvoke(asyncResult);


            Console.WriteLine("计算已经完成，记录一下日志 {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("******************btnAsyncAdvanced_Click 异步方法进阶 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }
        #endregion

        #region 0306
        /// <summary>
        /// 1 回顾委托和异步多线程
        /// 2 通过Task启动多线程
        /// 3 解决多线程几大应用场景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("******************btnAsyncAdvanced_Click 异步方法进阶 start {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Eleven老师接到一个私活。。");//这里都是Eleven老师在干事儿
            Console.WriteLine("沟通需求，谈妥价格");
            Console.WriteLine("签合同收取50%的费用");
            Console.WriteLine("高级班去筛选学员，组建团队");
            Console.WriteLine("需求分析、系统设计、模块划分");
            Console.WriteLine("开始干活。。。");

            //为了提升效率 为了人多力量大  就得多线程  就得并行
            TaskFactory taskFactory = new TaskFactory();
            List<Task> taskList = new List<Task>();

            taskList.Add(taskFactory.StartNew(() => this.Coding("流年", "Wechat")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("王亚峰", "Portal")));//.ContinueWith(t => Console.WriteLine("王亚峰开发完成"))
            taskList.Add(taskFactory.StartNew(() => this.Coding("Leah", "Client")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("心花怒放", "WCF")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("停转的星空", "DBA")));
            taskList.Add(taskFactory.StartNew(() => this.Coding("  右  ", "BackService")));
            //能不能指定特定某个人完成，执行对应操作
            taskList.Add(taskFactory.ContinueWhenAny(taskList.ToArray(), t =>
            //t.IsCompleted
            Console.WriteLine("第一个开发完成的获取红包奖励。。{0}", Thread.CurrentThread.ManagedThreadId)));
            taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), tList =>
            Console.WriteLine("全部开发任务完成，进入联调测试。。{0}", Thread.CurrentThread.ManagedThreadId)));

            //小作业：下午3点之前 完成小红包(5元)  怎么样知道是哪个人完成的，在ContinueWhenAny能不能打印出用户的名字


            Task.WaitAny(taskList.ToArray());//等待某个task的完成  才能执行下一行  卡主当前的运行线程
            Console.WriteLine("某个模块开发完成后，收取20%费用");
            Task.WaitAll(taskList.ToArray());//等待全部task的完成  才能执行下一行  卡主当前的运行线程
            Console.WriteLine("验收完成后，收取剩余的费用");
            Console.WriteLine("Eleven老师给大家分钱。。。");

            //this.Coding("流年", "Wechat");//单线程  同步方法

            //{ //1.0
            //    ThreadStart threadStart = new ThreadStart(() => this.Coding("流年", "Wechat"));
            //    Thread thread = new Thread(threadStart);
            //    thread.Start();
            //}
            //{
            //    //2.0
            //    WaitCallback waitCallback = new WaitCallback(o => this.Coding("流年", "Wechat"));
            //    ThreadPool.QueueUserWorkItem(waitCallback);
            //}
            //{
            //    //3.0
            //    Action action=new Action(() => this.Coding("流年", "Wechat"));
            //    Task.Run(action);
            //}
            //{
            //    Parallel.Invoke(() => this.Coding("流年", "Wechat"), () => this.Coding("流年", "Wechat"));
            //}
            //{
            //    //await async
            //}



            Console.WriteLine("******************btnAsyncAdvanced_Click 异步方法进阶 end   {0}********************", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// 一个耗时耗资源的测试方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine("******************DoSomethingLong start {0} {1} {2}********************",
                name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }

            Console.WriteLine("******************DoSomethingLong   end {0} {1} {2} {3}********************",
                name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"), lResult);
        }

        /// <summary>
        /// 模拟编程做私活 - -
        /// </summary>
        /// <param name="name"></param>
        /// <param name="project"></param>
        private void Coding(string name, string project)
        {
            Console.WriteLine("******************Coding start {0} {1} {2} {3}********************",
                name, project, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);

            Console.WriteLine("******************Coding   end {0} {1} {2} {3}********************",
                name, project, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));
        }
        #endregion

    }
}
