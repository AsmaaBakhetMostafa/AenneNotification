using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Job
{
    public class ScheduleTripBeforeTwoHoursJob
    {
        public static void TaskServices()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();

            IJobDetail jobDetail = JobBuilder.Create<TripBeforeTwoHoursJob>()
               .WithIdentity("TripBeforeTwoHoursJob")
               .Build();
            string dateString;
            DateTimeOffset offsetDate;
            dateString = "12:00 AM";
            offsetDate = DateTimeOffset.Parse(dateString);
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("TripBeforeTwoHoursJobTrigger")
                .StartAt(offsetDate)
                .WithSimpleSchedule(x => x.WithIntervalInHours(24)
                .RepeatForever())
                .Build();
            scheduler.ScheduleJob(jobDetail, trigger);
            scheduler.Start();
        }
    }
}
