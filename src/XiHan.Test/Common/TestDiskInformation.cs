﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:TestDiskInformation
// Guid:0979736c-d1d0-4cb2-ac75-950643d97cb4
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreatedTime:2022-06-30 上午 02:11:14
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using XiHan.Utils.Extensions;
using XiHan.Utils.HardwareInfos;

namespace XiHan.Test.Common;

/// <summary>
/// 测试磁盘信息
/// </summary>
public static class TestDiskInformation
{
    /// <summary>
    /// 磁盘信息测
    /// </summary>
    public static void DiskInformation()
    {
        Console.WriteLine(
            $@"【C盘】磁盘大小：{FormatFileSizeExtension.FormatByteToString(DiskHelper.GetHardDiskTotalSpace(@"C:\"))}；");
        Console.WriteLine(
            $@"【C盘】磁盘空余大小：{FormatFileSizeExtension.FormatByteToString(DiskHelper.GetHardDiskFreeSpace(@"C:\"))}；");
        Console.WriteLine($@"【C盘】磁盘空闲占比：{DiskHelper.ProportionOfHardDiskFreeSpace(@"C:\")}；");
        Console.WriteLine(
            $@"【D:\DataMine\Repository】目录大小：{FormatFileSizeExtension.FormatByteToString(FileHelper.GetDirectorySize(@"D:\DataMine\Repository"))}；");
        Console.WriteLine(
            $@"【D:\DataMine\Repository\XiHan.Framework\README.md】文件大小：{FormatFileSizeExtension.FormatByteToString(FileHelper.GetFileSize(@"D:\DataMine\Repository\XiHan.Framework\README.md"))}；");

        string[]? directories = FileHelper.GetDirectories(@"D:\");
        Console.WriteLine($@"【D:\】目录：");
        foreach (var directory in directories) Console.WriteLine(directory);
    }
}