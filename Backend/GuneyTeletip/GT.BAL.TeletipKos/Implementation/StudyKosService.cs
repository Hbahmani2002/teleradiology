using GT.BAL.TeletipKos.Model;
using GT.DataService.Implementation;
using GT.DataService.Model;
using GT.Repository.Models.View;
using GT.SERVICE;
using GT.UTILS.GRID;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.Extensions;

namespace GT.BAL.TeletipKos
{
    public class StudyKosService
    {
        StudyKosDataService _InfStudyDataService;
        public StudyKosService(IBussinessContext context)
        {
            _InfStudyDataService = new StudyKosDataService(context);
        }

        public MultipleOperationResultModel CreateKos(InfStudyFilter filter)
        {

            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }
        public void CreateKosBackground(InfStudyFilter filter)
        {

            var list = GetStudyKos(filter);
            CreateKos(list);
        }

        private static void CreateKos(IEnumerable<InfStudyViewModel> list)
        {
            foreach (var item in list)
            {

            }
        }

        public MultipleOperationResultModel MakeKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }
        public MultipleOperationResultModel MakeKosBackground(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }


        public MultipleOperationResultModel DeleteKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }

        public MultipleOperationResultModel DeleteKosBackground(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            return RandomDataGenerator.CreateRandom<MultipleOperationResultModel>(1).FirstOrDefault();
        }

        public void ReprocessKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void ReprocessKosBackground(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void UpdateReadKos(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void UpdateReadKosBackground(InfStudyFilter filter)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
            throw new NotImplementedException();
        }

        public void ExportExcel(InfStudyFilter filter, string filePath)
        {
            var list = GetStudyKos(filter);
            foreach (var item in list)
            {

            }
        }

        private IEnumerable<InfStudyViewModel> GetStudyKos(InfStudyFilter filter)
        {
            var grid = new Gridable<InfStudyFilter>();
            grid.Paging.Count = 1000;
            grid.Filter = filter;

            // var list = _InfStudyDataService.GetInfStudyList(grid).List;
            // return list;
            return RandomDataGenerator.CreateRandom<InfStudyViewModel>(12).ToList();
        }

    }
}
