﻿#region <<版权版本注释>>

// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:BaseValidationDto
// Guid:0abbb204-7b98-466b-987c-f10ff997b123
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-09-02 上午 12:28:58
// ----------------------------------------------------------------

#endregion <<版权版本注释>>

using Microsoft.AspNetCore.Mvc.Filters;
using XiHan.Utils.Extensions;

namespace XiHan.Infrastructures.Responses.Validations;

/// <summary>
/// 验证实体基类
/// </summary>
public class BaseValidationDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public BaseValidationDto(ActionExecutingContext context)
    {
        TotalCount = context.ModelState.Count;

        var a = context.ActionArguments.Select(s => s.Value);
        var sss = context.ModelState;

        ValidationErrorDto = context.ModelState.Keys
                .SelectMany(key => context.ModelState[key]!.Errors
                .Select(x => new BaseValidationErrorDto(key, key, x.ErrorMessage)))
                .ToList();
        // .GetSummary()
    }

    /// <summary>
    /// 数据总数
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// 验证出错字段
    /// </summary>
    public List<BaseValidationErrorDto>? ValidationErrorDto { get; }
}