﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SquadAsService.Application.Interfaces;
using SquadAsService.Application.Interfaces.Repo;
using SquadAsService.Domain.Bases;
using SquadAsService.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadAsService.Application.Features.Technologies.Queries.GetAll
{
    public record GetAllTechnologiesQuery:IRequest<BaseResponse<List<GetAllTechnologiesQueryDto>>>;

    internal class GetAllTechnologiesQueryHandler: IRequestHandler<GetAllTechnologiesQuery, BaseResponse<List<GetAllTechnologiesQueryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;

        public GetAllTechnologiesQueryHandler(
            IUnitOfWork unitOfWork,
            IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
        }

        public async Task<BaseResponse<List<GetAllTechnologiesQueryDto>>> Handle(GetAllTechnologiesQuery request, CancellationToken cancellationToken)
        {
            var technologies = await _unitOfWork.Repository<Technology>().Entities
                        .ProjectToType<GetAllTechnologiesQueryDto>()
                        .ToListAsync(cancellationToken);

            technologies.ForEach(x => x.IconUrl = _mediaService.GetUrl(x.IconUrl)!);

            return BaseResponse<List<GetAllTechnologiesQueryDto>>.Success(technologies);
        }
    }
}