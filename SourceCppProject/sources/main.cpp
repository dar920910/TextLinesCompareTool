#include "Services/AppIntelligentWorker.hpp"
#include "Services/AppLaunchConfiguration.hpp"


int main(int argc, char* argv[])
{
    AppIntelligentWorker::performTask(AppLaunchConfiguration(argc, argv));
    return EXIT_SUCCESS;
}