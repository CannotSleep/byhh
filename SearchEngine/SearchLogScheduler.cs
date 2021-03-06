﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Learun.Application.TwoDevelopment.LR_CodeDemo;

namespace SearchEngine
{
    /// <summary>
    /// 搜索日志定时任务调度器
    /// </summary>
    public static class SearchLogScheduler
    {
        public static void Start()
        {
            // 每隔一段时间执行任务
            IScheduler sched;
            ISchedulerFactory sf = new StdSchedulerFactory();
            sched = sf.GetScheduler();
            // IndexJob为实现了IJob接口的类
            JobDetail job = new JobDetail("job1", "group1", typeof(BuildStasticsJob));
            // 5秒后开始第一次运行
            DateTime ts = TriggerUtils.GetNextGivenSecondDate(null, 5);
            // 每隔1小时执行一次
            TimeSpan interval = TimeSpan.FromHours(1);
            // 每若干小时运行一次，小时间隔由appsettings中的IndexIntervalHour参数指定
            Trigger trigger = new SimpleTrigger("trigger1", "group1", "job1", "group1", ts, null,
                                                    SimpleTrigger.RepeatIndefinitely, interval);
            sched.AddJob(job, true);
            sched.ScheduleJob(trigger);
            sched.Start();
        }
    }


    /// <summary>
    /// 具体要执行的任务
    /// </summary>
    public class BuildStasticsJob : IJob
    {
        private SearchLogStaticService stasticService;
                
        public BuildStasticsJob()
        {
            stasticService = new SearchLogStaticService();
        }

        public void Execute(JobExecutionContext context)
        {
            // 删除所有统计记录
            stasticService.Delete();
            // 重新统计插入表中
            stasticService.Stastic(0,10);
        }
    }
}
