using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlohaGenerator.Generator
{
    public interface IGenerator: IDisposable
    {
        string[] SourceIds { get; }

        byte[] GetMessage();
    }
}
