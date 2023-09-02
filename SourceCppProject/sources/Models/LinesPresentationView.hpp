#ifndef LINES_PRESENTATION_VIEW_HPP_
#define LINES_PRESENTATION_VIEW_HPP_

#include "LinesStorageMap.hpp"
#include "LinesStorageSet.hpp"
#include "LinesRepository.hpp"


struct LinesResultMapBasedView
{
    LinesRepository<LinesStorageMap> content_from_sources;
    LinesStorageMap common_content_storage;
    LinesRepository<LinesStorageMap> unique_content_repository;
};

struct LinesResultSetBasedView
{
    LinesRepository<LinesStorageSet> content_from_sources;
    LinesStorageSet common_content_storage;
    LinesRepository<LinesStorageSet> unique_content_repository;
};


class LinesPresentationView
{
public:
    static const LinesResultMapBasedView createResultView(
        const LinesRepository<LinesStorageMap>& content_from_sources,
        const LinesStorageMap& common_content_storage,
        const LinesRepository<LinesStorageMap>& unique_content_repository
    );

    static const LinesResultSetBasedView createResultView(
        const LinesRepository<LinesStorageSet>& content_from_sources,
        const LinesStorageSet& common_content_storage,
        const LinesRepository<LinesStorageSet>& unique_content_repository
    );
};

#endif