#ifndef ARTIFACT_VALIDATOR_HPP_
#define ARTIFACT_VALIDATOR_HPP_

#include <string>


class ArtifactValidator
{
private:
    const std::string m_StringToValidate;

    const bool isLine() const;
    const bool startsWithPermissibleCharacter() const;
public:
    ArtifactValidator(const std::string& string_to_check);
    const bool isArtifact() const;
};

#endif