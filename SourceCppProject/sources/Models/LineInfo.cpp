#include "LineInfo.hpp"

#include "../Parsers/HashGenerator.hpp"


LineInfo::LineInfo(const std::string& target_string) : 
    m_LineString{target_string}, m_LineHash{HashGenerator::generateLineHash(target_string)}
{
}

LineInfo::LineInfo(const std::pair<const std::size_t, std::string>& target_pair) : 
    m_LineString{target_pair.second}, m_LineHash{target_pair.first}
{
}

const std::pair<const std::size_t, std::string> LineInfo::getContent() const
{
    return std::pair<const std::size_t, std::string>(m_LineHash, m_LineString);
}