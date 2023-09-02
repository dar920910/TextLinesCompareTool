#include "LinesPresentationView.hpp"

const LinesResultMapBasedView LinesPresentationView::createResultView(
        const LinesRepository<LinesStorageMap>& content_from_sources,
        const LinesStorageMap& common_content_storage,
        const LinesRepository<LinesStorageMap>& unique_content_repository)
{
    LinesResultMapBasedView result;

    result.content_from_sources = content_from_sources;
    result.common_content_storage = common_content_storage;
    result.unique_content_repository = unique_content_repository;
    
    return result;
}

const LinesResultSetBasedView LinesPresentationView::createResultView(
        const LinesRepository<LinesStorageSet>& content_from_sources,
        const LinesStorageSet& common_content_storage,
        const LinesRepository<LinesStorageSet>& unique_content_repository)
{
    LinesResultSetBasedView result;

    result.content_from_sources = content_from_sources;
    result.common_content_storage = common_content_storage;
    result.unique_content_repository = unique_content_repository;
    
    return result;
}