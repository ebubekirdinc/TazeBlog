using System;
using System.Collections.Generic;
using System.Text;

namespace TazeBlog.Core.Utilities.Abstract
{
    public interface ICryptoService
    {
        string CreateSalt(int size);
        string Encrypt(string plainText, string passPhrase);
        string Decrypt(string cipherText, string passPhrase);
    }
}
