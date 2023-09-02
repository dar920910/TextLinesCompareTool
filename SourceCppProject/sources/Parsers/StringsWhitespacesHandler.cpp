#include "StringsWhitespacesHandler.hpp"

#include "GeneralCharacterValidator.hpp"


StringsWhitespacesHandler::StringsWhitespacesHandler(const std::string& target_string)
{
    m_TargetString = target_string;
}


const std::string StringsWhitespacesHandler::trimStartWhitespaces()
{
    const std::string::const_iterator end_of_string {m_TargetString.end()};
    std::string::const_iterator current_position {m_TargetString.begin()};

    while (current_position != end_of_string)
    {
        if (GeneralCharacterValidator::isSpaceCharacter(*current_position))
        {
            current_position++;
        }
        else
        {
            break;
        }
    }

    return std::string {current_position, end_of_string};
}

const std::string StringsWhitespacesHandler::trimEndWhitespaces()
{
    const std::string::const_iterator begin_of_string {m_TargetString.begin()};
    const std::string::const_iterator end_of_string {m_TargetString.end()};

    std::string::const_iterator current_position {end_of_string - 1};

    while (current_position != begin_of_string)
    {
        if (GeneralCharacterValidator::isSpaceCharacter(*current_position))
        {
            current_position--;
        }
        else
        {
            break;
        }
    }

    return std::string {begin_of_string, current_position + 1};
}

const std::string StringsWhitespacesHandler::trimRedunantWhitespaces()
{
    std::string::iterator artifact_iterator {m_TargetString.begin()};

    while (artifact_iterator != m_TargetString.end())
    {
        if (GeneralCharacterValidator::isSpaceCharacter(*artifact_iterator))
        {
            processWhitespacesRange(artifact_iterator);
        }

        artifact_iterator++;
    }

    const std::string trimmed_string {m_TargetString};
    return trimmed_string;
}

void StringsWhitespacesHandler::processWhitespacesRange(const std::string::iterator whitespaces_range_start)
{
    const int offset_to_next_whitespace {1};
    const std::string::iterator next_whitespace_it {whitespaces_range_start + offset_to_next_whitespace};

    if (GeneralCharacterValidator::isSpaceCharacter(*next_whitespace_it))
    {
        cutWhitespacesRange(next_whitespace_it, findWhitespacesRangeEnd(next_whitespace_it));
    }
}

const std::string::iterator StringsWhitespacesHandler::findWhitespacesRangeEnd(const std::string::iterator whitespaces_range_start) const
{
    std::string::iterator whitespaces_range_end {whitespaces_range_start};

    while (GeneralCharacterValidator::isSpaceCharacter(*whitespaces_range_end))
    {
        whitespaces_range_end++;
    }

    return whitespaces_range_end;
}

void StringsWhitespacesHandler::cutWhitespacesRange(const std::string::iterator start_range_it, const std::string::iterator end_range_it)
{
    const std::string whitespace_placeholder {""};
    m_TargetString.replace(start_range_it, end_range_it, whitespace_placeholder);
}