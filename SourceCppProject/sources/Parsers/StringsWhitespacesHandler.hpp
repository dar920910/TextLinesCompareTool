#ifndef STRINGS_WHITESPACES_HANDLER_HPP_
#define STRINGS_WHITESPACES_HANDLER_HPP_

#include <iterator>
#include <string>


class StringsWhitespacesHandler
{
private:
    std::string m_TargetString;

    void processWhitespacesRange(const std::string::iterator whitespaces_range_start);
    const std::string::iterator findWhitespacesRangeEnd(const std::string::iterator whitespaces_range_start) const;
    void cutWhitespacesRange(const std::string::iterator start_range_it, const std::string::iterator end_range_it);
public:
    StringsWhitespacesHandler(const std::string& target_string);

    const std::string trimStartWhitespaces();
    const std::string trimEndWhitespaces();

    const std::string trimRedunantWhitespaces();
};

#endif