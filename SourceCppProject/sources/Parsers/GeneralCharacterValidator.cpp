#include "GeneralCharacterValidator.hpp"

#include <cctype>


bool GeneralCharacterValidator::isNotCommentCharacter(const char& character)
{
    const char comment_character {'#'};

    if (character == comment_character)
    {
        return false;
    }

    return true;
}

bool GeneralCharacterValidator::isSpaceCharacter(const char& character)
{
    return std::isspace(character);
}