﻿namespace DynamicTranslator.Core.Service
{
    #region using

    using System.Threading.Tasks;
    using DBReezeNoSQL.Repository;
    using Dependency.Markers;
    using Orchestrators;

    #endregion

    public class ResultService : IResultService, ITransientDependency
    {
        private readonly ITranslateResultRepository resultRepository;

        public ResultService(ITranslateResultRepository resultRepository)
        {
            this.resultRepository = resultRepository;
        }

        public CompositeTranslateResult Save(string key, CompositeTranslateResult translateResult)
        {
            return resultRepository.SetTranslateResult(key, translateResult);
        }

        public CompositeTranslateResult SaveAndUpdateFrequency(string key, CompositeTranslateResult translateResult)
        {
            return resultRepository.SetTranslateResultAndUpdateFrequency(key, translateResult);
        }

        public async Task<CompositeTranslateResult> SaveAsync(string key, CompositeTranslateResult translateResult)
        {
            return await resultRepository.SetTranslateResultAsync(key, translateResult);
        }

        public async Task<CompositeTranslateResult> SaveAndUpdateFrequencyAsync(string key, CompositeTranslateResult translateResult)
        {
            return await resultRepository.SetTranslateResultAndUpdateFrequencyAsync(key, translateResult);
        }

        public CompositeTranslateResult Get(string key)
        {
            return resultRepository.GetTranslateResult(key);
        }

        public async Task<CompositeTranslateResult> GetAsync(string key)
        {
            return await resultRepository.GetTranslateResultAsync(key);
        }
    }
}