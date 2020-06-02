﻿#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

namespace DG.DoctcoD.Service
{
    public partial class ServiceMain : AB.Service.ABServiceBase
    {
        public ServiceMain()
        {
            ServiceWorker serviceWorker = new ServiceWorker();
            ServiceManager = new AB.Service.ABServiceManager(60, () => serviceWorker.Do());

            InitializeComponent();
        }
    }
}
