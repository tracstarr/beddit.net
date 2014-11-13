using System.Collections.Generic;
using Beddit.Net.Enum;
using Beddit.Net.Model;
using Beddit.Net.ResponseModel;

namespace Beddit.Net
{
    internal static class BedditExtensions
    {
        public static List<BedditSleepData> ToBedditSleepData(this List<BedditRawSleepDataResponse> data)
        {
            if (data == null)
                return null;

            if (data.Count == 0)
                return new List<BedditSleepData>();

            var sleepData = new List<BedditSleepData>();

            foreach (var bedditRawSleepDataResponse in data)
            {
                var entity = new BedditSleepData()
                {
                    Date = bedditRawSleepDataResponse.Date,
                    Properties = bedditRawSleepDataResponse.Properties,
                    SessionRangeEnd = bedditRawSleepDataResponse.SessionRangeEnd,
                    SessionRangeStart = bedditRawSleepDataResponse.SessionRangeStart,
                    StartTimestamp = bedditRawSleepDataResponse.StartTimestamp,
                    Tags = bedditRawSleepDataResponse.Tags,
                    Tips = bedditRawSleepDataResponse.Tips,
                    TimeZone = bedditRawSleepDataResponse.TimeZone,
                    Updated = bedditRawSleepDataResponse.Updated
                };

                if (bedditRawSleepDataResponse.TimeValueTracks != null)
                {
                    if (bedditRawSleepDataResponse.TimeValueTracks.AlarmEvent != null)
                    {
                        var alarmEvents = bedditRawSleepDataResponse.TimeValueTracks.AlarmEvent.Items;
                        if (alarmEvents != null)
                        {
                            entity.Alarms = new List<BedditAlarm>();

                            foreach (var eventItem in alarmEvents)
                            {
                                int alarm = (int)eventItem[1];
                                var alarmItem = new BedditAlarm() { TimeStamp = eventItem[0], Event = (BedditAlarmEventEnum)alarm };
                                entity.Alarms.Add(alarmItem);
                            }
                        }
                    }

                    if (bedditRawSleepDataResponse.TimeValueTracks.HeartRateCurve != null)
                    {
                        var hrcEvents = bedditRawSleepDataResponse.TimeValueTracks.HeartRateCurve.Items;
                        if (hrcEvents != null)
                        {
                            entity.HeartRate = new List<BedditHeartRate>();

                            foreach (var eventItem in hrcEvents)
                            {
                                var hrcItem = new BedditHeartRate() { TimeStamp = eventItem[0], Event = eventItem[1] };
                                entity.HeartRate.Add(hrcItem);
                            }
                        }
                    }

                    if (bedditRawSleepDataResponse.TimeValueTracks.SleepCycles != null)
                    {
                        var sleepCycles = bedditRawSleepDataResponse.TimeValueTracks.SleepCycles.Items;
                        if (sleepCycles != null)
                        {
                            entity.SleepCycles = new List<BedditSleepCycle>();

                            foreach (var eventItem in sleepCycles)
                            {
                                var item = new BedditSleepCycle() { TimeStamp = eventItem[0], Event = eventItem[1] };
                                entity.SleepCycles.Add(item);
                            }
                        }
                    }

                    if (bedditRawSleepDataResponse.TimeValueTracks.SnoringEpisodes != null)
                    {
                        var snoringEpisodes = bedditRawSleepDataResponse.TimeValueTracks.SnoringEpisodes.Items;
                        if (snoringEpisodes != null)
                        {
                            entity.Snoring = new List<BedditSnoring>();

                            foreach (var eventItem in snoringEpisodes)
                            {
                                var item = new BedditSnoring() { TimeStamp = eventItem[0], Event = eventItem[1] };
                                entity.Snoring.Add(item);
                            }
                        }
                    }

                    if (bedditRawSleepDataResponse.TimeValueTracks.SleepStages != null)
                    {
                        var sleepStages = bedditRawSleepDataResponse.TimeValueTracks.SleepStages.Items;
                        if (sleepStages != null)
                        {
                            entity.SleepStages = new List<BedditSleepStage>();

                            foreach (var eventItem in sleepStages)
                            {
                                int eType = (int)eventItem[1];
                                var item = new BedditSleepStage() { TimeStamp = eventItem[0], Event = (BedditSleepStagesEnum)eType };
                                entity.SleepStages.Add(item);
                            }
                        }
                    }

                    if (bedditRawSleepDataResponse.TimeValueTracks.Presence != null)
                    {
                        var presence = bedditRawSleepDataResponse.TimeValueTracks.Presence.Items;
                        if (presence != null)
                        {
                            entity.Presence = new List<BedditPresence>();

                            foreach (var eventItem in presence)
                            {
                                var item = new BedditPresence() { TimeStamp = eventItem[0], Event = eventItem[1] };
                                entity.Presence.Add(item);
                            }
                        }
                    }
                }
                sleepData.Add(entity);
            }

            return sleepData;
        }
    }
}