namespace MobileBandSync.OpenTcx
{
    using System;

    internal sealed class Validator
    {
        private string errMsg;

        public bool Validate(string XMLFile, bool LocationDefined);

        public string validationErrMsg { get; set; }
    }
}

