namespace DPUruNet
{
class NFIQ
    {
        public enum NFIQ_ALGORITHM { NFIQ_NIST=1,NFIQ_AWARE }
        public enum NFIQ_SCORE { EXCELLENT = 1, GOOD, AVERAGE, POOR, UNACCEPTABLE };
             
        [DllImport("dpfj.dll")]
        private static extern int dpfj_quality_nfiq_from_fid(int fid_type,byte[] FIDData,uint FIDSize,uint viewIndex,int qualityAlgorithm,ref uint score);

        //Method to calculate NFIQ score from supplied FID (scores are 1-5.  See NFIQ_SCORE)
        public static NFIQ_SCORE GetScore(DPUruNet.Fid fid, NFIQ_ALGORITHM algorithm)
        {
            int fid_type = 0;
            uint score = 0;

            if (fid.Format == DPUruNet.Constants.Formats.Fid.ANSI)
                fid_type = 0x001B0401; //DPFJ_FID_ANSI_381_2004 from dpfj.h
            else if (fid.Format == DPUruNet.Constants.Formats.Fid.ISO)
                fid_type = 0x01010007; //DPFJ_FID_ISO_19794_4_2005 from dpfj.h

            if (dpfj_quality_nfiq_from_fid(fid_type, fid.Bytes, (uint)fid.Bytes.Length, 0, (int)algorithm, ref score) == 0)
                return (NFIQ_SCORE)score;

            throw new Exception("Failed to generate NFIQ score");
        }
    }
}