#include "ArtifactValidator.hpp"

#include "GeneralCharacterValidator.hpp"


ArtifactValidator::ArtifactValidator(const std::string& string_to_check) : m_StringToValidate(string_to_check)
{
}

const bool ArtifactValidator::isArtifact() const
{
    if (isLine())
    {
        if (startsWithPermissibleCharacter())
        {
            return true;
        }
    }

    return false;
}

const bool ArtifactValidator::isLine() const
{
    if (m_StringToValidate.empty())
    {
        return false;
    }

    return true;
}

const bool ArtifactValidator::startsWithPermissibleCharacter() const
{
    std::string::const_iterator current_position {m_StringToValidate.begin()};

    while (current_position != m_StringToValidate.end())
    {
        if (GeneralCharacterValidator::isSpaceCharacter(*current_position))
        {
            current_position++;
            continue;
        }
        else if (GeneralCharacterValidator::isNotCommentCharacter(*current_position))
        {
            return true;
        }
        else
        {
            break;
        }
    }

    return false;
}