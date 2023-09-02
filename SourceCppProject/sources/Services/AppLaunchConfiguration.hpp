#ifndef APP_LAUNCH_CONFIGURATION_HPP_
#define APP_LAUNCH_CONFIGURATION_HPP_

#include <string>
#include <vector>


class AppLaunchConfiguration
{
private:
    std::vector<std::string> m_arguments_of_sources {};
public:
    AppLaunchConfiguration(int argc, char* argv[]);
    const std::vector<std::string> getArgumentsOfSources() const;
};

#endif