﻿using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimIdShouldExistWhenSelected(int id)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(predicate: i => i.Id == id, enableTracking: false);
            if (result == null)
                throw new BusinessException(OperationClaimMessages.OperationClaimNotExists);
        }
    }
}
