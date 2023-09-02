#include "StringsCommentsHandler.hpp"

#include "GeneralCharacterValidator.hpp"


StringsCommentsHandler::StringsCommentsHandler(const std::string& target_string)
{
    m_TargetString = target_string;
}


const std::string StringsCommentsHandler::trimSingleStringComment()
{
    const std::string::const_iterator begin_of_artifact {m_TargetString.begin()};
    std::string::const_iterator begin_of_comment {begin_of_artifact};

    while (begin_of_comment != m_TargetString.end())
    {
        if (GeneralCharacterValidator::isNotCommentCharacter(*begin_of_comment))
        {
            begin_of_comment++;
        }
        else
        {
            break;
        }
    }

    return std::string {begin_of_artifact, begin_of_comment};
}

const std::string StringsCommentsHandler::trimWrappedCommentsInsideString()
{
    std::string::iterator artifact_iterator {m_TargetString.begin()};

    while (artifact_iterator != m_TargetString.end())
    {
        if (isCommentInsideString(artifact_iterator))
        {
            const std::string::iterator end_of_comment = findIteratorPositionAfterEndingOfComment(artifact_iterator);
            cutCommentInsideString(artifact_iterator, end_of_comment);
        }

        artifact_iterator++;
    }

    const std::string string_without_comments {m_TargetString};
    return string_without_comments;
}

const bool StringsCommentsHandler::isCommentInsideString(const std::string::iterator artifact_iterator) const
{
    if (isCommentSlash(*artifact_iterator))
    {
        if (isCommentAsterisk(getNextCharacter(artifact_iterator)))
        {
            return true;
        }
    }

    return false;
}

const bool StringsCommentsHandler::isCommentAsterisk(const char target_character) const
{
    const char comment_asterisk {'*'};
    return target_character == comment_asterisk;
}

const bool StringsCommentsHandler::isCommentSlash(const char target_character) const
{
    const char comment_slash {'/'};
    return target_character == comment_slash;
}

const char StringsCommentsHandler::getNextCharacter(const std::string::iterator current_character) const
{
    const int offset {1};
    const std::string::iterator next_character {current_character + offset};

    return *next_character;
}

const std::string::iterator StringsCommentsHandler::findIteratorPositionAfterEndingOfComment(const std::string::iterator comment_start) const
{
    std::string::iterator comment_end {comment_start};

    while (comment_end != m_TargetString.end())
    {
        char current_character {*comment_end};

        if (isCommentAsterisk(current_character))
        {
            current_character = getNextCharacter(comment_end);

            if (isCommentSlash(current_character))
            {
                comment_end++;
                break;
            }
        }

        comment_end++;
    }

    const int offset_after_comment {1};
    const std::string::iterator position_after_comment {comment_end + offset_after_comment};

    return position_after_comment;
}

void StringsCommentsHandler::cutCommentInsideString(const std::string::iterator comment_begin, const std::string::iterator comment_end)
{
    const std::string comment_placeholder {""};
    m_TargetString.replace(comment_begin, comment_end, comment_placeholder);
}