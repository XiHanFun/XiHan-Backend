﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2023 ZhaiFanhua All Rights Reserved.
// Licensed under the MulanPSL2 License. See LICENSE in the project root for license information.
// FileName:ISysLoginLogService
// Guid:b76c9bed-1830-43d7-9775-c56203578b8e
// Author:Administrator
// Email:me@zhaifanhua.com
// CreateTime:2023-07-19 下午 02:54:42
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using XiHan.Infrastructures.Responses.Pages;
using XiHan.Models.Syses;
using XiHan.Services.Bases;
using XiHan.Services.Syses.Logins.Dtos;

namespace XiHan.Services.Syses.Logins;

/// <summary>
/// ISysLoginLogService
/// </summary>
public interface ISysLoginLogService : IBaseService<SysLoginLog>
{
    /// <summary>
    /// 新增登录日志
    /// </summary>
    /// <param name="loginLog"></param>
    /// <returns></returns>
    Task CreateLoginLog(SysLoginLog loginLog);

    /// <summary>
    /// 批量删除登录日志
    /// </summary>
    /// <param name="logIds"></param>
    /// <returns></returns>
    Task<bool> DeleteLoginLogByIds(long[] logIds);

    /// <summary>
    /// 清空登录日志
    /// </summary>
    Task<bool> CleanLoginLog();

    /// <summary>
    /// 查询登录日志(根据Id)
    /// </summary>
    /// <param name="logId"></param>
    /// <returns></returns>
    Task<SysLoginLog> GetLoginLogById(long logId);

    /// <summary>
    /// 查询登录日志列表(根据分页条件)
    /// </summary>
    /// <param name="pageWhere"></param>
    /// <returns></returns>
    Task<PageDataDto<SysLoginLog>> GetLoginLogBList(PageWhereDto<SysLoginLogWDto> pageWhere);
}