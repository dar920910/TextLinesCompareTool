#include "AbstractOutputDevice.hpp"


void AbstractOutputDevice::printArtifacts(const LinesResultMapBasedView& result_artifact)
{
    printUncommentedContent(result_artifact.content_from_sources);
    printUniqueContent(result_artifact.unique_content_repository);
    printCommonContent(result_artifact.common_content_storage);
}

void AbstractOutputDevice::printArtifacts(const LinesResultSetBasedView& result_artifact)
{
    printUncommentedContent(result_artifact.content_from_sources);
    printUniqueContent(result_artifact.unique_content_repository);
    printCommonContent(result_artifact.common_content_storage);
}


const std::string AbstractOutputDevice::getDelimiter() const
{
    const unsigned short delimiter_size = 10;
    const char delimiter_char = '=';

    return std::string(delimiter_size, delimiter_char);
}

const std::string AbstractOutputDevice::getSubDelimiter() const
{
    const unsigned short delimiter_size = 5;
    const char delimiter_char = '-';

    return std::string(delimiter_size, delimiter_char);
}