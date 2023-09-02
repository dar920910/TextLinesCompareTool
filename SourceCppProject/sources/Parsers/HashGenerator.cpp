#include "HashGenerator.hpp"


const std::size_t HashGenerator::generateLineHash(const std::string& target_string)
{
    return std::hash<std::string>{}(target_string);
}