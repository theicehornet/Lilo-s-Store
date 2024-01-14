﻿using System.Security.Cryptography;
using System.Text;

namespace proyecto_lilo.Recursos
{
    public class Utilidades
    {
        public static string EncriptarContra(string passw)
        {
            if (string.IsNullOrEmpty(passw))
                throw new Exception("La contraseña no puede estar vacía");
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(passw));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}