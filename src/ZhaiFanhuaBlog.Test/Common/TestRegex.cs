﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:TestRegex
// Guid:b5401227-996f-45d0-b2b1-2c84742f344c
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-11-29 上午 03:26:21
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using MySqlX.XDevAPI.Common;
using ZhaiFanhuaBlog.Utils.Verification;

namespace ZhaiFanhuaBlog.Test.Common;

/// <summary>
/// TestRegex
/// </summary>
public class TestRegex
{
    // 身份证号
    public static void TestCardId()
    {
        Console.WriteLine("输入身份证号码");
        string? cardId = Console.ReadLine();
        if (cardId != null)
        {
            var result = RegexHelper.IsNumber_People(cardId);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("输入错误");
        }
    }
}