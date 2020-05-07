using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApp.Job
{
    public class ScheduleTripBefore12HoursJob
    {
        public static void TaskServices()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();

            IJobDetail jobDetail = JobBuilder.Create<TripBefore12HoursJob>()
               .WithIdentity("TripBefore12HoursJob")
               .Build();
            string dateString;
            DateTimeOffset offsetDate;
            dateString = "12:00 AM";
            offsetDate = DateTimeOffset.Parse(dateString);
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("TripBefore12HoursJobTrigger")
                .StartAt(offsetDate)
                .WithSimpleSchedule(x => x.WithIntervalInHours(24)
                .RepeatForever())
                .Build();
            scheduler.ScheduleJob(jobDetail, trigger);
            scheduler.Start();
        }
    }
}
