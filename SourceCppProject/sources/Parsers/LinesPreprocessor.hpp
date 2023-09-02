#ifndef LINES_PREPROCESSOR_HPP_
#define LINES_PREPROCESSOR_HPP_

#include <string>


class LinesPreprocessor
{
private:
    std::string m_LineToProcessing;
public:
    LinesPreprocessor(const std::string& string_to_processing);
    const std::string retrievePreprocessedArtifact();
};

#endif