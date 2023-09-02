#ifndef STRINGS_COMMENTS_HANDLER_HPP_
#define STRINGS_COMMENTS_HANDLER_HPP_

#include <iterator>
#include <string>


class StringsCommentsHandler
{
private:
    std::string m_TargetString;

    const bool isCommentInsideString(const std::string::iterator artifact_iterator) const;
    const bool isCommentAsterisk(const char target_character) const;
    const bool isCommentSlash(const char target_character) const;
    const char getNextCharacter(const std::string::iterator current_character) const;
    const std::string::iterator findIteratorPositionAfterEndingOfComment(const std::string::iterator comment_start) const;

    void cutCommentInsideString(const std::string::iterator comment_begin, const std::string::iterator comment_end);
public:
    StringsCommentsHandler(const std::string& target_string);

    const std::string trimSingleStringComment();
    const std::string trimWrappedCommentsInsideString();
};

#endif