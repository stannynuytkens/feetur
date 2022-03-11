using Feetur.Application.Data;
using Feetur.Application.Data.Entities;

namespace Feetur.Infrastructure.Data.Repositories;

public class FeatureRepository: Repository<Feature<bool>>, IRepository<Feature<bool>> { }