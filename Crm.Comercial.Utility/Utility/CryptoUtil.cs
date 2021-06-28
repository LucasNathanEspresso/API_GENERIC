using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class CryptoUtil
{

    public string Criptografar(string Senha)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            return RetonarHash(md5Hash, Senha);
        }
    }

    public bool ValidarSenha(string senhaUsr, string SenhaCript)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            var senha = Criptografar(senhaUsr);
            if (VerificarHash(md5Hash, SenhaCript, senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private string RetonarHash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();
    }

    private bool VerificarHash(MD5 md5Hash, string input, string hash)
    {
        StringComparer compara = StringComparer.OrdinalIgnoreCase;

        if (0 == compara.Compare(input, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

