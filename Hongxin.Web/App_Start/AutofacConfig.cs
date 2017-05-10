﻿using Autofac;
using Autofac.Integration.Mvc;
using Hongxin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace Hongxin.Web.App_Start
{
    /// <summary>
    /// Autofac依赖注入配置
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = RegisterService();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        /// <summary>
        /// 注入实现
        /// </summary>
        /// <returns></returns>
        private static ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependency);

            //扫描IService和Service相关的程序集

            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();


            builder.RegisterControllers(assemblys.ToArray());

            //自动注入
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
            return builder;
        }
    }
}