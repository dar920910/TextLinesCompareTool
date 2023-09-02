#include "ConsoleOutputPrinter.hpp"

#include <iostream>


void ConsoleOutputPrinter::printLineInfo(const LineInfo& target_info)
{
    const std::pair<std::size_t, std::string> content = target_info.getContent();

    std::cout << "LINE: ";
    printLinePairKey(content);
    printLinePairValue(content);
    std::cout << std::endl;
}

void ConsoleOutputPrinter::printLineInfo(const std::pair<std::size_t, std::string>& pair_info)
{
    std::cout << "LINE: ";
    printLinePairKey(pair_info);
    printLinePairValue(pair_info);
    std::cout << std::endl;
}

void ConsoleOutputPrinter::printLineInfo(const std::string& target_line)
{
    std::cout << "LINE: ";
    std::cout << "\'" << target_line << "\'";
    std::cout << std::endl;
}



void ConsoleOutputPrinter::printLinePairKey(const std::pair<std::size_t, std::string>& pair)
{
    std::cout << "key = ";
    std::cout << std::hex << pair.first;
    std::cout << " | ";
}

void ConsoleOutputPrinter::printLinePairValue(const std::pair<std::size_t, std::string>& pair)
{
    std::cout << "value = ";
    std::cout << "\"" << pair.second << "\"";
    std::cout << " | ";
}



void ConsoleOutputPrinter::printUncommentedContent(const LinesStorageMap& target_content)
{
    printUncommentedContentTitle(target_content.getName());

    const std::unordered_map<std::size_t, std::string> uncommented_lines = target_content.getContent();

    for (const std::pair<std::size_t, std::string>& uncommented_line : uncommented_lines)
    {
        printLineInfo(uncommented_line);
    }

    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUncommentedContent(const LinesStorageSet& target_content)
{
    printUncommentedContentTitle(target_content.getName());

    const auto uncommented_lines = target_content.getContent();

    for (const std::string& uncommented_line : uncommented_lines)
    {
        printLineInfo(uncommented_line);
    }

    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUncommentedContent(const LinesRepository<LinesStorageMap>& content_repos)
{
    printContentTitle("UNCOMMENTED LINES FROM ALL FILES");

    const auto content_collection = content_repos.getContent();

    for (const LinesStorageMap& content_element : content_collection)
    {
        printUncommentedContent(content_element);
    }
}

void ConsoleOutputPrinter::printUncommentedContent(const LinesRepository<LinesStorageSet>& content_repos)
{
    printContentTitle("UNCOMMENTED LINES FROM ALL FILES");

    const auto content_collection = content_repos.getContent();

    for (const LinesStorageSet& content_element : content_collection)
    {
        printUncommentedContent(content_element);
    }
}



void ConsoleOutputPrinter::printCommonContent(const LinesStorageMap& target_content)
{
    printContentTitle("COMMON LINES MAP");

    const auto target_content_map = target_content.getContent();

    for (const std::pair<std::size_t, std::string>& element : target_content_map)
    {
        printLineInfo(element);
    }

    std::cout << std::endl;
}

void ConsoleOutputPrinter::printCommonContent(const LinesStorageSet& target_content)
{
    printContentTitle("COMMON LINES SET");

    const auto target_content_set = target_content.getContent();

    for (const std::string& common_line : target_content_set)
    {
        printLineInfo(common_line);
    }

    std::cout << std::endl;
}


void ConsoleOutputPrinter::printUniqueContent(const LinesStorageMap& content_element)
{
    printUniqueContentTitle(content_element.getName());

    const auto content_element_map = content_element.getContent();

    for (const std::pair<std::size_t, std::string>& content_pair : content_element_map)
    {
        printLineInfo(content_pair);
    }

    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUniqueContent(const LinesStorageSet& content_element)
{
    printUniqueContentTitle(content_element.getName());

    const auto content_element_set = content_element.getContent();
    
    for (const std::string& content_unit : content_element_set)
    {
        printLineInfo(content_unit);
    }

    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUniqueContent(const LinesRepository<LinesStorageMap>& repos)
{
    printContentTitle("UNIQUE LINES MAPS (HASH + STRING)");

    const auto content_collection = repos.getContent();

    for (const LinesStorageMap& content_element : content_collection)
    {
        printUniqueContent(content_element);
    }

    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUniqueContent(const LinesRepository<LinesStorageSet>& repos)
{
    printContentTitle("UNIQUE LINES (SETS OF STRINGS)");

    for (const LinesStorageSet& unique_object : repos.getContent())
    {
        printUniqueContent(unique_object);
    }

    std::cout << std::endl;
}


void ConsoleOutputPrinter::printContentTitle(const std::string& title_text)
{
    std::cout << "\n" << getDelimiter();
    std::cout << " " << title_text << " ";
    std::cout << getDelimiter() << "\n";
    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUncommentedContentTitle(const std::string& source_name)
{
    std::cout << getSubDelimiter() << " ";
    std::cout << "UNCOMMENTED LINES: " << source_name;
    std::cout << " " << getSubDelimiter() << "\n";
    std::cout << std::endl;
}

void ConsoleOutputPrinter::printUniqueContentTitle(const std::string& source_name)
{
    std::cout << getSubDelimiter() << " ";
    std::cout << "UNIQUE LINES: " << source_name;
    std::cout << " " << getSubDelimiter() << "\n";
    std::cout << std::endl;
}