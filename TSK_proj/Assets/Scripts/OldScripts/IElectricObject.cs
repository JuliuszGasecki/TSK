﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElectricObject
{
     void SetVoltage(double voltage);
     void SetCurrent(double current);
}