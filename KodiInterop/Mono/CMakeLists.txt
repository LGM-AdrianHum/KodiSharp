cmake_minimum_required(VERSION 3.0)

if(CMAKE_BUILD_TYPE STREQUAL "")
	set(CMAKE_BUILD_TYPE Debug)
endif(CMAKE_BUILD_TYPE STREQUAL "")

find_package(PkgConfig REQUIRED)
pkg_check_modules(MONO REQUIRED mono-2)

include_directories(
	${MONO_INCLUDE_DIRS}
)

link_directories(
	${MONO_LIBRARY_DIRS}
)

add_library(monoHost SHARED
	host.c
	utils.c
)

target_link_libraries(monoHost
	${MONO_LIBRARIES}
)
