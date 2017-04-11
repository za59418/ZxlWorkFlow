using System;
using System.Collections.Generic;
using System.Text;
using DCIIDS.Main;
using Zxl.Data;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Zxl.WebSite.ModelView
{
    [JsonObject()]
    public class ServiceResult
    {
        public ServiceResult()
        {
            ReturnCode = ServiceResultCode.Warning;
        }

        /// <summary>
        ///     初始化一个 业务操作结果信息类 的新实例
        /// </summary>
        /// <param name="resultType">业务操作结果代码</param>
        public ServiceResult(ServiceResultCode resultCode)
        {
            ReturnCode = resultCode;
        }

        /// <summary>
        ///  初始化一个 定义返回消息的业务操作结果信息类 的新实例
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="message"></param>
        public ServiceResult(ServiceResultCode resultCode, string message)
            : this(resultCode)
        {
            this.Message = message;
        }
        public ServiceResultCode ReturnCode { get; set; }
        /// <summary>
        ///     获取或设置 操作返回信息
        /// </summary>
        /// 
        public string Message { get; set; }

        public string Action { get; set; }
    }

    public class ServiceResult<T> : ServiceResult where T : class
    {
        public ServiceResult()
        {
            ReturnCode = ServiceResultCode.Warning;
        }

        /// <summary>
        ///     初始化一个 业务操作结果信息类 的新实例
        /// </summary>
        /// <param name="resultType">业务操作结果代码</param>
        public ServiceResult(ServiceResultCode resultCode)
            : base(resultCode)
        {
            this.ResultType = "object";
        }

        /// <summary>
        ///  初始化一个 定义返回消息的业务操作结果信息类 的新实例
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="message"></param>
        public ServiceResult(ServiceResultCode resultCode, string message)
            : base(resultCode, message)
        {
            this.ResultType = "object";
        }

        /// <summary>
        /// 初始化一个 定义返回消息与附加数据的业务操作结果信息类 的新实例
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="message"></param>
        /// <param name="appendData"></param>
        public ServiceResult(ServiceResultCode resultCode, string message, T appendData)
            : this(resultCode, message)
        {
            this.Data = appendData;
        }

        /// <summary>
        /// 获取和设置返回值的类型.类型可以为 object|list|tree
        /// </summary>
        public string ResultType { get; set; }

        /// <summary>
        /// 获取或设置返回映射类类型
        /// </summary>
        public string ModelType { get; set; }

        /// <summary>
        /// 获取和设置返回数据
        /// </summary>
        public T Data { get; set; }
    }

        /// <summary>
    ///     表示业务操作结果的枚举
    /// </summary>
    [Description("业务操作结果的枚举")]
    public enum ServiceResultCode
    {
        /// <summary>
        ///     操作成功
        /// </summary>
        [Description("操作成功。")]
        Success = 0,
        /// <summary>
        ///     操作取消或操作没引发任何变化
        /// </summary>
        [Description("操作没有引发任何变化，提交取消。")]
        NoChanged,

        /// <summary>
        ///     参数错误
        /// </summary>
        [Description("参数错误。")]
        ParamError,

        /// <summary>
        ///     指定参数的数据不存在
        /// </summary>
        [Description("指定参数的数据不存在。")]
        QueryNull,

        /// <summary>
        ///     权限不足
        /// </summary>
        [Description("当前用户权限不足，不能继续操作。")]
        PurviewLack,

        /// <summary>
        ///     非法操作
        /// </summary>
        [Description("非法操作。")]
        IllegalOperation,

        /// <summary>
        ///     警告
        /// </summary>
        [Description("警告")]
        Warning,

        /// <summary>
        ///     操作引发错误
        /// </summary>
        [Description("操作引发错误。")]
        Error,
    }
}
