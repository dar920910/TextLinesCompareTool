#ifndef FILE_OUTPUT_PRINTER_HPP_
#define FILE_OUTPUT_PRINTER_HPP_

#include "AbstractOutputDevice.hpp"

#include <fstream>


class FileOutputPrinter : public AbstractOutputDevice
{
private:
    std::ofstream m_OutputFileStream;
protected:
    const std::string generateOutputFileName() const;

    void printLineInfo(const LineInfo& target_info);
    void printLineInfo(const std::pair<std::size_t, std::string>& target_line);
    void printLineInfo(const std::string& target_line);

    void printLinePairKey(const std::pair<std::size_t, std::string>& pair);
    void printLinePairValue(const std::pair<std::size_t, std::string>& pair);

    void printUncommentedContent(const LinesStorageMap& target_content);
    void printUncommentedContent(const LinesStorageSet& target_content);
    void printUncommentedContent(const LinesRepository<LinesStorageMap>& content_repos);
    void printUncommentedContent(const LinesRepository<LinesStorageSet>& content_repos);

    void printCommonContent(const LinesStorageMap& target_content);
    void printCommonContent(const LinesStorageSet& target_content);

    void printUniqueContent(const LinesStorageMap& content_element);
    void printUniqueContent(const LinesStorageSet& content_element);
    void printUniqueContent(const LinesRepository<LinesStorageMap>& repos);
    void printUniqueContent(const LinesRepository<LinesStorageSet>& repos);

    void printContentTitle(const std::string& title_text);
    void printUncommentedContentTitle(const std::string& source_name);
    void printUniqueContentTitle(const std::string& source_name);
public:
    FileOutputPrinter();
    ~FileOutputPrinter();
};

#endif