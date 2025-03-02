using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NumberOneTask;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

 
    public Time()
    {
        _hour = 0;
        _minute = 0;
        _second = 0;
        _millisecond = 0;            
    }

    public Time(int hour)
    {
        _hour = ValidHour(hour);
        _minute = 0;
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour, int minute)
    {
        _hour = ValidHour(hour);
        _minute = ValidMinute(minute);
        _second = 0;
        _millisecond = 0;
    }

    public Time(int hour, int minute, int second)
    {
        _hour = ValidHour(hour);
        _minute = ValidMinute(minute);
        _second = ValidSecond(second);
        _millisecond = 0;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        _hour = ValidHour(hour);
        _minute = ValidMinute(minute);
        _second = ValidSecond(second);
        _millisecond = ValidMillisecond(millisecond);
    }

    public int Hour { 
        get => _hour; 
        set
        {
         _hour = ValidHour(value);
        }
               
    }

    public int Minute
    {
        get => _minute;
        set
        {
         _minute = ValidMinute(value);
        }
        
    }

    public int Second
    {
        get => _second;
        set
        {
         _second = ValidSecond(value);
        }
            
    }

    public int Millisecond
    {
        get => _millisecond;
        set
        {
         _millisecond = ValidMillisecond(value);
        }            
    }

    public override string ToString()
    {
        return $"{_hour % 12:00}:{_minute:00}:{_second:00}.{_millisecond:000} {(_hour < 12 ? "AM" : "PM")}";
    }

    public int ToMilliseconds()
    {
        return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }


    public Time Add(Time other)
    {
        int newMilliseconds = _millisecond + other._millisecond;
        int newSeconds = _second + other._second + (newMilliseconds / 1000);
        newMilliseconds %= 1000;

        int newMinutes = _minute + other._minute + (newSeconds / 60);
        newSeconds %= 60;

        int newHours = _hour + other._hour + (newMinutes / 60);
        newMinutes %= 60;

        newHours %= 24;

        return new Time(newHours, newMinutes, newSeconds, newMilliseconds);
    }

    public bool IsOtherDay(Time other)
    {
        return (_hour + other._hour) >= 24;
    }

    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
            throw new ArgumentException($"The hour: {hour}, is not valid.");
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
            throw new ArgumentException($"The minute: {minute}, is not valid.");
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
            throw new ArgumentException($"The second: {second}, is not valid.");
        return second;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
            throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");
        return millisecond;
    }
}
