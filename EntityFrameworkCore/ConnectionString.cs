﻿namespace EntityFrameworkCore
{
    public sealed class ConnectionString
    {
        public string Value { get; }

        public ConnectionString(string value)
        {
            Value = value;
        }
    }
}
