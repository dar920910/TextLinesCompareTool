cmake_minimum_required(VERSION 3.15)
project(lines_explorer_proj)

set(CMAKE_CXX_STANDARD 11)

include(FetchContent)
FetchContent_Declare(
  googletest
  URL https://github.com/google/googletest/archive/e2239ee6043f73722e7aa812a459f54a28552929.zip
)

set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(googletest)

add_executable(
        lines_explorer
        sources/main.cpp

        sources/Models/LineInfo.cpp
        sources/Models/LineInfo.hpp

        sources/Models/LinesPresentationView.cpp
        sources/Models/LinesPresentationView.hpp

        sources/Models/LinesRepository.cpp
        sources/Models/LinesRepository.hpp

        sources/Models/LinesStorageMap.cpp
        sources/Models/LinesStorageMap.hpp

        sources/Models/LinesStorageSet.cpp
        sources/Models/LinesStorageSet.hpp

        sources/Models/SourceInfo.cpp
        sources/Models/SourceInfo.hpp

        sources/Models/SourcesExplorer.cpp
        sources/Models/SourcesExplorer.hpp

        sources/Parsers/ArtifactValidator.cpp
        sources/Parsers/ArtifactValidator.hpp

        sources/Parsers/GeneralCharacterValidator.cpp
        sources/Parsers/GeneralCharacterValidator.hpp

        sources/Parsers/HashGenerator.cpp
        sources/Parsers/HashGenerator.hpp

        sources/Parsers/LinesMainProcessor.cpp
        sources/Parsers/LinesMainProcessor.hpp

        sources/Parsers/LinesPreprocessor.cpp
        sources/Parsers/LinesPreprocessor.hpp

        sources/Parsers/StringsCommentsHandler.cpp
        sources/Parsers/StringsCommentsHandler.hpp

        sources/Parsers/StringsWhitespacesHandler.cpp
        sources/Parsers/StringsWhitespacesHandler.hpp

        sources/Printers/AbstractOutputDevice.hpp
        sources/Printers/AbstractOutputDevice.cpp

        sources/Printers/ConsoleOutputPrinter.cpp
        sources/Printers/ConsoleOutputPrinter.hpp

        sources/Printers/FileOutputPrinter.cpp
        sources/Printers/FileOutputPrinter.hpp

        sources/Printers/WebOutputPrinter.cpp
        sources/Printers/WebOutputPrinter.hpp

        sources/Services/AppDatetimeService.cpp
        sources/Services/AppDatetimeService.hpp

        sources/Services/AppIntelligentWorker.cpp
        sources/Services/AppIntelligentWorker.hpp

        sources/Services/AppLaunchConfiguration.cpp
        sources/Services/AppLaunchConfiguration.hpp
)

add_library(
        files_pack
        INTERFACE
        examples
)
add_custom_command(
        OUTPUT examples
        COMMAND
        ${CMAKE_COMMAND} -E copy_directory
        ${CMAKE_CURRENT_SOURCE_DIR}/examples
        ${CMAKE_CURRENT_BINARY_DIR}/examples
        COMMENT "Copy scripts to example_files"
        DEPENDS
        examples/agile-spam/AGILE-RUS.txt
        examples/agile-spam/AGILE-SPA.txt
        examples/agile-spam/AGILE-SWE.txt
        examples/agile-spam/AGILE-NLD.txt
        examples/agile-spam/AGILE-TUR.txt
        examples/agile-spam/AGILE-UKR.txt
        examples/agile-spam/AGILE-FRE.txt
        examples/agile-spam/AGILE-GER.txt
        examples/agile-spam/AGILE-HUN.txt
        examples/agile-spam/AGILE-ITA.txt
        examples/comments/file_1.txt
        examples/comments/file_2.txt
        examples/comments/file_3.txt
        examples/lorem-ipsum/demo_1.txt
        examples/lorem-ipsum/demo_2.txt
        examples/lorem-ipsum/demo_3.txt
        examples/lorem-ipsum/demo_4.txt
        examples/lorem-ipsum/demo_5.txt
        examples/lorem-ipsum/demo_6.txt
        examples/lorem-ipsum/demo_7.txt
        examples/my-tests/test_1.txt
        examples/my-tests/test_2.txt
        examples/my-tests/test_3.txt
        examples/my-tests/test_4.txt
)

target_link_libraries(
        lines_explorer
        PUBLIC
        files_pack
)

enable_testing()

add_executable(
        lines_explorer_test

        sources/Models/LineInfo.cpp
        sources/Models/LineInfo.hpp
        sources/Models/LineInfoTest.cpp

        sources/Models/LinesRepository.cpp
        sources/Models/LinesRepository.hpp
        sources/Models/LinesRepositoryTest.cpp

        sources/Models/LinesStorageMap.cpp
        sources/Models/LinesStorageMap.hpp
        sources/Models/LinesStorageMapTest.cpp

        sources/Models/LinesStorageSet.cpp
        sources/Models/LinesStorageSet.hpp
        sources/Models/LinesStorageSetTest.cpp

        sources/Parsers/ArtifactValidator.cpp
        sources/Parsers/ArtifactValidator.hpp
        sources/Parsers/ArtifactValidatorTest.cpp

        sources/Parsers/GeneralCharacterValidator.cpp
        sources/Parsers/GeneralCharacterValidator.hpp
        sources/Parsers/GeneralCharacterValidatorTest.cpp

        sources/Parsers/HashGenerator.cpp
        sources/Parsers/HashGenerator.hpp
        sources/Parsers/HashGeneratorTest.cpp

        sources/Parsers/LinesMainProcessor.cpp
        sources/Parsers/LinesMainProcessor.hpp
        sources/Parsers/LinesMainProcessorTest.cpp

        sources/Parsers/LinesPreprocessor.cpp
        sources/Parsers/LinesPreprocessor.hpp
        sources/Parsers/LinesPreprocessorTest.cpp

        sources/Parsers/StringsCommentsHandler.cpp
        sources/Parsers/StringsCommentsHandler.hpp
        sources/Parsers/StringsCommentsHandlerTest.cpp

        sources/Parsers/StringsWhitespacesHandler.cpp
        sources/Parsers/StringsWhitespacesHandler.hpp
        sources/Parsers/StringsWhitespacesHandlerTest.cpp

        sources/Services/AppDatetimeService.cpp
        sources/Services/AppDatetimeService.hpp
        sources/Services/AppDatetimeServiceTest.cpp

        sources/Services/AppLaunchConfiguration.cpp
        sources/Services/AppLaunchConfiguration.hpp
        sources/Services/AppLaunchConfigurationTest.cpp
)
# MSVC settings for default debug build gtest library.
# The value is ignored on non-MSVC compilers.
set_property(
        TARGET lines_explorer_test
        PROPERTY
        MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>"
)

target_link_libraries(
  lines_explorer_test
  gtest_main
)

include_directories(
        "${gtest_SOURCE_DIR}/include"
        "${gmock_SOURCE_DIR}/include"
)

include(GoogleTest)
gtest_discover_tests(lines_explorer_test)