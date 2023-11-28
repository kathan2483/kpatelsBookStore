﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KpatelsBooks.DataAccess.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        T Single<T>(String procedurename, DynamicParameters param = null);
        void Execute(String procedurename, DynamicParameters param = null);

        T OneRecord<T>(String procedurename, DynamicParameters param = null);

        IEnumerable<T> List<T>(String procedurename, DynamicParameters param = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(String procedurename, DynamicParameters param = null);
    }
}
