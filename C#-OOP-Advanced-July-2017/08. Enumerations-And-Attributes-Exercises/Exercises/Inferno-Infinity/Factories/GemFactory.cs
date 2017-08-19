﻿using System;
using System.Collections.Generic;

public class GemFactory : IGemFactory
{
    public IBaseGem Create(IList<string> tokens)
    {
        var clarity = tokens[0];
        var gemType = tokens[1];
        IBaseGem gem = null;
        switch (gemType)
        {
            case "Ruby":
                gem = new Ruby(clarity);
                break;
            case "Emerald":
                gem = new Emerald(clarity);
                break;
            case "Amethyst":
                gem = new Amethyst(clarity);
                break;
            default:
                throw new ArgumentException("Invalid gem type!");
        }

        return gem;
    }
}