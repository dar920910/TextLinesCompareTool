#ifndef LINE_INFO_HPP_
#define LINE_INFO_HPP_

#include <string>
#include <utility>


class LineInfo
{
private:
    const std::string m_LineString;
    const std::size_t m_LineHash;
public:
    LineInfo(const std::string& target_string);
    LineInfo(const std::pair<const std::size_t, std::string>& target_pair);

    const std::pair<const std::size_t, std::string> getContent() const;
};

#endif