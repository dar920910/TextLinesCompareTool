#include "WebOutputPrinter.hpp"

#include "../Services/AppDatetimeService.hpp"

#define HASH_OUTPUT


WebOutputPrinter::WebOutputPrinter()
{
    m_WebOutputFileStream.open(generateOutputFileName(), std::ios_base::out);
}

WebOutputPrinter::~WebOutputPrinter()
{
    m_WebOutputFileStream.close();
}


const std::string WebOutputPrinter::generateOutputFileName() const
{
    return std::string(AppDatetimeService::getCurrentDatetimeText() + ".html");
}


const std::string WebOutputPrinter::generateWebPageBegin()
{
    std::string hypertext {"<!DOCTYPE html>"};

    hypertext += "<html lang=\"en\">\n";
    hypertext += "<head>\n";
    hypertext += getDocumentCharset("UTF-8");
    hypertext += getDocumentName("Results");
    hypertext += getStyles();
    hypertext += "</head>\n";
    hypertext += "<body>\n";

    return hypertext;
}

const std::string WebOutputPrinter::getDocumentCharset(const std::string& charset)
{
    return std::string("<meta charset=\"" + charset + "\">\n");
}

const std::string WebOutputPrinter::getDocumentName(const std::string& title)
{
    return std::string("<title>" + title + "</title>\n");
}

const std::string WebOutputPrinter::getStyles()
{
    const std::string all_lines_css {" .all { color: green; font-size: 125%; } "};
    const std::string common_lines_css {" .common { color: red; font-size: 125%; } "};
    const std::string unique_lines_css {" .unique { color: blue; font-size: 125%; } "};
    
    const std::string styles = "<style>" + all_lines_css + common_lines_css + unique_lines_css + "</style>\n";

    return styles;
}

const std::string WebOutputPrinter::generateWebPageEnd()
{
    return std::string("\n</body>\n</html>");
}



void WebOutputPrinter::printArtifacts(const LinesResultMapBasedView& result_artifact)
{
    m_WebOutputFileStream << generateWebPageBegin();

    printUncommentedContent(result_artifact.content_from_sources);
    printUniqueContent(result_artifact.unique_content_repository);
    printCommonContent(result_artifact.common_content_storage);

    m_WebOutputFileStream << generateWebPageEnd();
}

void WebOutputPrinter::printArtifacts(const LinesResultSetBasedView& result_artifact)
{
    m_WebOutputFileStream << generateWebPageBegin();

    printUncommentedContent(result_artifact.content_from_sources);
    printUniqueContent(result_artifact.unique_content_repository);
    printCommonContent(result_artifact.common_content_storage);

    m_WebOutputFileStream << generateWebPageEnd();
}



void WebOutputPrinter::printLineInfo(const LineInfo& target_info)
{
    const std::pair<std::size_t, std::string> content = target_info.getContent();

#ifndef HASH_OUTPUT
    printLinePairKey(content);
#endif
    printLinePairValue(content);
}

void WebOutputPrinter::printLineInfo(const std::pair<std::size_t, std::string>& pair_info)
{
#ifndef HASH_OUTPUT
    printLinePairKey(pair_info);
#endif
    printLinePairValue(pair_info);
}

void WebOutputPrinter::printLineInfo(const std::string& target_line)
{
    m_WebOutputFileStream << "\'" << target_line << "\'";
}



void WebOutputPrinter::printLinePairKey(const std::pair<std::size_t, std::string>& pair)
{
    m_WebOutputFileStream << "key = ";
    m_WebOutputFileStream << std::hex << pair.first;
    m_WebOutputFileStream << " | ";
}

void WebOutputPrinter::printLinePairValue(const std::pair<std::size_t, std::string>& pair)
{
    m_WebOutputFileStream << "value = ";
    m_WebOutputFileStream << "\"" << pair.second << "\"";
    m_WebOutputFileStream << " | ";
}



void WebOutputPrinter::printUncommentedContent(const LinesStorageMap& target_content)
{
    printUncommentedContentTitle(target_content.getName());

    const std::unordered_map<std::size_t, std::string> uncommented_lines = target_content.getContent();

    for (const std::pair<std::size_t, std::string>& uncommented_line : uncommented_lines)
    {
        m_WebOutputFileStream << "<p class='all'>";
        m_WebOutputFileStream << "LINE: ";
        printLineInfo(uncommented_line);
        m_WebOutputFileStream << std::string("</p>\n");
    }

    m_WebOutputFileStream << std::string("<br>\n");
}

void WebOutputPrinter::printUncommentedContent(const LinesStorageSet& target_content)
{
    printUncommentedContentTitle(target_content.getName());

    const auto uncommented_lines = target_content.getContent();

    for (const std::string& uncommented_line : uncommented_lines)
    {
        m_WebOutputFileStream << "<p>";
        m_WebOutputFileStream << "LINE: ";
        printLineInfo(uncommented_line);
        m_WebOutputFileStream << std::string("</p>\n");
    }

    m_WebOutputFileStream << std::string("<br>\n");
}

void WebOutputPrinter::printUncommentedContent(const LinesRepository<LinesStorageMap>& content_repos)
{
    printContentTitle("UNCOMMENTED LINES FROM ALL FILES");

    const auto content_collection = content_repos.getContent();

    for (const LinesStorageMap& content_element : content_collection)
    {
        printUncommentedContent(content_element);
    }
}

void WebOutputPrinter::printUncommentedContent(const LinesRepository<LinesStorageSet>& content_repos)
{
    printContentTitle("UNCOMMENTED LINES FROM ALL FILES");

    const auto content_collection = content_repos.getContent();

    for (const LinesStorageSet& content_element : content_collection)
    {
        printUncommentedContent(content_element);
    }
}



void WebOutputPrinter::printCommonContent(const LinesStorageMap& target_content)
{
    printContentTitle("COMMON LINES MAP");

    const auto target_content_map = target_content.getContent();

    for (const std::pair<std::size_t, std::string>& element : target_content_map)
    {
        m_WebOutputFileStream << "<p class='common'>";
        m_WebOutputFileStream << "LINE: ";
        printLineInfo(element);
        m_WebOutputFileStream << std::string("</p>\n");
    }

    m_WebOutputFileStream << std::string("<br>\n");
}

void WebOutputPrinter::printCommonContent(const LinesStorageSet& target_content)
{
    printContentTitle("COMMON LINES SET");

    const auto target_content_set = target_content.getContent();

    for (const std::string& common_line : target_content_set)
    {
        m_WebOutputFileStream << "<p class='common'>";
        m_WebOutputFileStream << "LINE: ";
        printLineInfo(common_line);
        m_WebOutputFileStream << std::string("</p>\n");
    }

    m_WebOutputFileStream << std::string("<br>\n");
}


void WebOutputPrinter::printUniqueContent(const LinesStorageMap& content_element)
{
    printUniqueContentTitle(content_element.getName());

    const auto content_element_map = content_element.getContent();

    for (const std::pair<std::size_t, std::string>& content_pair : content_element_map)
    {
        m_WebOutputFileStream << "<p class='unique'>";
        m_WebOutputFileStream << "LINE: ";
        printLineInfo(content_pair);
        m_WebOutputFileStream << std::string("</p>\n");
    }

    m_WebOutputFileStream << std::string("<br>");
}

void WebOutputPrinter::printUniqueContent(const LinesStorageSet& content_element)
{
    printUniqueContentTitle(content_element.getName());

    const auto content_element_set = content_element.getContent();
    
    for (const std::string& content_unit : content_element_set)
    {
        m_WebOutputFileStream << "<p class='unique'>";
        m_WebOutputFileStream << "LINE: ";
        printLineInfo(content_unit);
        m_WebOutputFileStream << std::string("</p>\n");
    }

    m_WebOutputFileStream << std::string("<br>\n");
}

void WebOutputPrinter::printUniqueContent(const LinesRepository<LinesStorageMap>& repos)
{
    printContentTitle("UNIQUE LINES MAPS (HASH + STRING)");

    const auto content_collection = repos.getContent();

    for (const LinesStorageMap& content_element : content_collection)
    {
        printUniqueContent(content_element);
    }

    m_WebOutputFileStream << std::string("<br>\n");
}

void WebOutputPrinter::printUniqueContent(const LinesRepository<LinesStorageSet>& repos)
{
    printContentTitle("UNIQUE LINES (SETS OF STRINGS)");

    for (const LinesStorageSet& unique_object : repos.getContent())
    {
        printUniqueContent(unique_object);
    }

    m_WebOutputFileStream << std::string("<br>\n");
}


void WebOutputPrinter::printContentTitle(const std::string& title_text)
{
    std::string hypertext {};

    hypertext = "<br><h2>" + getDelimiter();
    hypertext += " " + title_text + " ";
    hypertext += getDelimiter() + "</h2><br>\n";

    m_WebOutputFileStream << hypertext;
}

void WebOutputPrinter::printUncommentedContentTitle(const std::string& source_name)
{
    std::string hypertext {};

    hypertext = "<h3>" + getSubDelimiter() + " ";
    hypertext += "UNCOMMENTED LINES: " + source_name;
    hypertext += " " + getSubDelimiter() + "</h3><br>\n";

    m_WebOutputFileStream << hypertext;
}

void WebOutputPrinter::printUniqueContentTitle(const std::string& source_name)
{
    std::string hypertext {};

    hypertext = "<h3>" + getSubDelimiter() + " ";
    hypertext += "UNIQUE LINES: " + source_name;
    hypertext += " " + getSubDelimiter() + "</h3><br>\n";

    m_WebOutputFileStream << hypertext;
}