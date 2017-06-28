﻿using System;

class DateModifier
{
    private double result;
    private DateTime firstDate;
    private DateTime secondDate;

    public DateModifier(string firstDate, string secondDate)
    {
        var isFirstParsed = DateTime.TryParse(firstDate, out this.firstDate);
        var isSecondParsed = DateTime.TryParse(secondDate, out this.secondDate);
        
        if (isFirstParsed && isSecondParsed)
        {
            this.result =Math.Abs((this.firstDate - this.secondDate).TotalDays);
        }
        else
        {
            throw new Exception("Invalid Dates");
        }
    }

    public double Result
    {
        get
        {
            return this.result;
        }
    }
}