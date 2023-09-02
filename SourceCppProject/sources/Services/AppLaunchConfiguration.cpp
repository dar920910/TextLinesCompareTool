#include "AppLaunchConfiguration.hpp"

#include <cstring>
#include <string>


AppLaunchConfiguration::AppLaunchConfiguration(int argc, char* argv[])
{
    for (int arg_index = 1; arg_index < argc; arg_index++)
    {
        std::string current_argument {argv[arg_index]};
        m_arguments_of_sources.push_back(current_argument);
    }
}

const std::vector<std::string> AppLaunchConfiguration::getArgumentsOfSources() const
{
    return m_arguments_of_sources;
}