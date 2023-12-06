using CompetitionProjectMars.JSONDataObject;
using Newtonsoft.Json;
using CompetitionProjectMars.Pages;

namespace CompetitionProjectMars.Utilities
{
    public class JsonDataReader
    {
        //private readonly string filePath;
        private readonly string _sampleJsonFilePath;
        public JsonDataReader(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Login> ReadLoginFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<Login> list = JsonConvert.DeserializeObject<List<Login>>(json);
            return list;

        }

        public List<AddCertifications> ReadCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddCertifications> list = JsonConvert.DeserializeObject<List<AddCertifications>>(json);
            return list;

        }

        public List<AddCertificationInvalidInput> ReadCertificationInvalidInputFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddCertificationInvalidInput> list = JsonConvert.DeserializeObject<List<AddCertificationInvalidInput>>(json);
            return list;

        }

        public List<AddExistingCertification> ReadExistingCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingCertification> list = JsonConvert.DeserializeObject<List<AddExistingCertification>>(json);
            return list;

        }
        public List<AddExistingCertificationwithDifferentYear> ReadExistingCertificationWithDifferentYearFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingCertificationwithDifferentYear> list = JsonConvert.DeserializeObject<List<AddExistingCertificationwithDifferentYear>>(json);
            return list;

        }

        public List<UpdateCertification> ReadUpdateCeritificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<UpdateCertification> list = JsonConvert.DeserializeObject<List<UpdateCertification>>(json);
            return list;

        }
        public List<DeleteCertification> ReadDeleteCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<DeleteCertification> list = JsonConvert.DeserializeObject<List<DeleteCertification>>(json);
            return list;

        }

        public List<AddEducation> ReadAddEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddEducation> list = JsonConvert.DeserializeObject<List<AddEducation>>(json);
            return list;

        }

        public List<AddEducationInvalidInput> ReadEducationInvalidInputFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddEducationInvalidInput> list = JsonConvert.DeserializeObject<List<AddEducationInvalidInput>>(json);
            return list;

        }

        public List<AddExistingEducation> ReadAddExistingEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingEducation> list = JsonConvert.DeserializeObject<List<AddExistingEducation>>(json);
            return list;

        }

        public List<AddExistingEducationwithDifferentYear> ReadAddExistingEducationWithDifferentYearFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingEducationwithDifferentYear> list = JsonConvert.DeserializeObject<List<AddExistingEducationwithDifferentYear>>(json);
            return list;

        }

        public List<UpdateEducation> ReadUpdateEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<UpdateEducation> list = JsonConvert.DeserializeObject<List<UpdateEducation>>(json);
            return list;

        }

        public List<DeleteEducation> ReadDeleteEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<DeleteEducation> list = JsonConvert.DeserializeObject<List<DeleteEducation>>(json);
            return list;

        }


    }


}




    

