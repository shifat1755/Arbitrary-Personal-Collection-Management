using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace APCM.Services.CommonService
{
    public class CommonService:ICommonService
    {
        public string DoHashing(string data)
        {

            const int hashSize = 256;
            IDigest digest=new Sha3Digest(hashSize);
            byte[] inputBytes=Encoding.UTF8.GetBytes(data);
            digest.BlockUpdate(inputBytes,0,inputBytes.Length);
            byte[] bytes=new byte[digest.GetDigestSize()];
            digest.DoFinal(bytes,0);
            string hashedData=BitConverter.ToString(bytes).Replace("-","");
            return hashedData;
        }
    }
}
