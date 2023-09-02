#include "FileOutputPrinter.hpp"

#include "../Services/AppDatetimeService.hpp"


FileOutputPrinter::FileOutputPrinter()
{
    m_OutputFileStream.open(generateOutputFileName(), std::ios_base::out);
}

FileOutputPrinter::~FileOutputPrinter()
{
    m_OutputFileStream.close();
}

const std::string FileOutputPrinter::generateOutputFileName() const
{
    return std::string(AppDatetimeService::getCurrentDatetimeText() + ".result");
}


void FileOutputPrinter::printLineInfo(const LineInfo& target_info)
{
    const std::pair<std::size_t, std::string> content = target_info.getContent();

    m_OutputFileStream << "LINE: ";
    printLinePairKey(content);
    printLinePairValue(content);
    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printLineInfo(const std::pair<std::size_t, std::string>& pair_info)
{
    m_OutputFileStream << "LINE: ";
    printLinePairKey(pair_info);
    printLinePairValue(pair_info);
    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printLineInfo(const std::string& target_line)
{
    m_OutputFileStream << "LINE: ";
    m_OutputFileStream << "\'" << target_line << "\'";
    m_OutputFileStream << std::endl;
}



void FileOutputPrinter::printLinePairKey(const std::pair<std::size_t, std::string>& pair)
{
    m_OutputFileStream << "key = ";
    m_OutputFileStream << std::hex << pair.first;
    m_OutputFileStream << " | ";
}

void FileOutputPrinter::printLinePairValue(const std::pair<std::size_t, std::string>& pair)
{
    m_OutputFileStream << "value = ";
    m_OutputFileStream << "\"" << pair.second << "\"";
    m_OutputFileStream << " | ";
}



void FileOutputPrinter::printUncommentedContent(const LinesStorageMap& target_content)
{
    printUncommentedContentTitle(target_content.getName());

    const std::unordered_map<std::size_t, std::string> uncommented_lines = target_content.getContent();

    for (const std::pair<std::size_t, std::string>& uncommented_line : uncommented_lines)
    {
        printLineInfo(uncommented_line);
    }

    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUncommentedContent(const LinesStorageSet& target_content)
{
    printUncommentedContentTitle(target_content.getName());

    const auto uncommented_lines = target_content.getContent();

    for (const std::string& uncommented_line : uncommented_lines)
    {
        printLineInfo(uncommented_line);
    }

    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUncommentedContent(const LinesRepository<LinesStorageMap>& content_repos)
{
    printContentTitle("UNCOMMENTED LINES FROM ALL FILES");

    const auto content_collection = content_repos.getContent();

    for (const LinesStorageMap& content_element : content_collection)
    {
        printUncommentedContent(content_element);
    }
}

void FileOutputPrinter::printUncommentedContent(const LinesRepository<LinesStorageSet>& content_repos)
{
    printContentTitle("UNCOMMENTED LINES FROM ALL FILES");

    const auto content_collection = content_repos.getContent();

    for (const LinesStorageSet& content_element : content_collection)
    {
        printUncommentedContent(content_element);
    }
}



void FileOutputPrinter::printCommonContent(const LinesStorageMap& target_content)
{
    printContentTitle("COMMON LINES MAP");

    const auto target_content_map = target_content.getContent();

    for (const std::pair<std::size_t, std::string>& element : target_content_map)
    {
        printLineInfo(element);
    }

    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printCommonContent(const LinesStorageSet& target_content)
{
    printContentTitle("COMMON LINES SET");

    const auto target_content_set = target_content.getContent();

    for (const std::string& common_line : target_content_set)
    {
        printLineInfo(common_line);
    }

    m_OutputFileStream << std::endl;
}


void FileOutputPrinter::printUniqueContent(const LinesStorageMap& content_element)
{
    printUniqueContentTitle(content_element.getName());

    const auto content_element_map = content_element.getContent();

    for (const std::pair<std::size_t, std::string>& content_pair : content_element_map)
    {
        printLineInfo(content_pair);
    }

    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUniqueContent(const LinesStorageSet& content_element)
{
    printUniqueContentTitle(content_element.getName());

    const auto content_element_set = content_element.getContent();
    
    for (const std::string& content_unit : content_element_set)
    {
        printLineInfo(content_unit);
    }

    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUniqueContent(const LinesRepository<LinesStorageMap>& repos)
{
    printContentTitle("UNIQUE LINES MAPS (HASH + STRING)");

    const auto content_collection = repos.getContent();

    for (const LinesStorageMap& content_element : content_collection)
    {
        printUniqueContent(content_element);
    }

    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUniqueContent(const LinesRepository<LinesStorageSet>& repos)
{
    printContentTitle("UNIQUE LINES (SETS OF STRINGS)");

    for (const LinesStorageSet& unique_object : repos.getContent())
    {
        printUniqueContent(unique_object);
    }

    m_OutputFileStream << std::endl;
}


void FileOutputPrinter::printContentTitle(const std::string& title_text)
{
    m_OutputFileStream << "\n" << getDelimiter();
    m_OutputFileStream << " " << title_text << " ";
    m_OutputFileStream << getDelimiter() << "\n";
    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUncommentedContentTitle(const std::string& source_name)
{
    m_OutputFileStream << getSubDelimiter() << " ";
    m_OutputFileStream << "UNCOMMENTED LINES: " << source_name;
    m_OutputFileStream << " " << getSubDelimiter() << "\n";
    m_OutputFileStream << std::endl;
}

void FileOutputPrinter::printUniqueContentTitle(const std::string& source_name)
{
    m_OutputFileStream << getSubDelimiter() << " ";
    m_OutputFileStream << "UNIQUE LINES: " << source_name;
    m_OutputFileStream << " " << getSubDelimiter() << "\n";
    m_OutputFileStream << std::endl;
}