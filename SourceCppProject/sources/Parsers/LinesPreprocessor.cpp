#include "LinesPreprocessor.hpp"

#include "StringsCommentsHandler.hpp"
#include "StringsWhitespacesHandler.hpp"


LinesPreprocessor::LinesPreprocessor(const std::string& string_to_processing)
{
    m_LineToProcessing = string_to_processing;
}

const std::string LinesPreprocessor::retrievePreprocessedArtifact()
{
    std::string artifact {m_LineToProcessing};

    // WARNING:
    // This algorithm of preprocessing has the strict defined order.
    // If you swap its steps, your unit tests from LinesPreprocessorTest can fail !!!

    // 1. Preprocessing for C-style comments inside the string.
    artifact = StringsCommentsHandler(artifact).trimWrappedCommentsInsideString();
    // 2. Preprocessing for the single line Unix-style comment in the string.
    artifact = StringsCommentsHandler(artifact).trimSingleStringComment();
    // 3. Preprocessing for redunant whitespaces inside the string.
    artifact = StringsWhitespacesHandler(artifact).trimRedunantWhitespaces();
    // 4. Preprocessing for redunant whitespaces in the string's start.
    artifact = StringsWhitespacesHandler(artifact).trimStartWhitespaces();
    // 5. Preprocessing for redunant whitespaces in the string's end.
    artifact = StringsWhitespacesHandler(artifact).trimEndWhitespaces();

    return artifact;
}